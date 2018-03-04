<?php
namespace AppBundle\Controller;
use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;
class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $taskRepository = $this->getDoctrine()->getRepository(Task::class); // Взимаме от базата
        $tasksOpen = $taskRepository->findBy(["status" => "Open"]); // Намира всички Tasks със Статус Open
        $tasksInProgress = $taskRepository->findBy(["status" => "In Progress"]); // Намира всички Tasks със Статус In Progress
        $tasksFinished = $taskRepository->findBy(["status" => "Finished"]); // Намира всички Tasks със Статус Finished
        return $this->render(
            ':task:index.html.twig',
            ["openTasks" => $tasksOpen,
                "inProgressTasks" => $tasksInProgress,
                "finishedTasks" => $tasksFinished]
        );
    }
    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $task = new Task();
        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);
        if($form->isSubmitted() && $form->isValid()){
            if($task->getTitle() == null || $task->getStatus() == null){
                return $this->redirectToRoute('create');
            }
            $em = $this->getDoctrine()->getManager(); //Дай ми Entity Manager-а, той знае как се пише, трие в базата и т.н
            $em->persist($task); // Вземи от паметта и го натикай в базата данни - създай нова задача с тези данни
            $em->flush(); // save в базата
            return $this->redirectToRoute('index');
        }
        return $this->render(':task:create.html.twig',
            ["task" => $task, "form" => $form->createView()]);
    }
    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $taskRepository = $this->getDoctrine()->getRepository(Task::class); // Взима от базата
        $task = $taskRepository->find($id); // Намира Task по ID
        if($task == null){
            return $this->redirectToRoute('index');
        }
        $form = $this->createForm(TaskType::class, $task); // Създаваме форма за това и я записваме в $task
        $form->handleRequest($request); // обработваме заявката
        if($form->isSubmitted() && $form->isValid()){
            $em = $this->getDoctrine()->getManager(); // Ползваме Entity Manager за да записваме, трием и т.н
            $em->merge($task); // merge == SaveOrUpdate в C#, обновява конкретния Task в базата
            $em->flush(); // Запазваме Промените
            return $this->redirectToRoute('index');
        }
        return $this->render(':task:edit.html.twig',
            ['task' => $task, 'form' => $form->createView()]); // Подаваме Task и Form в инициативен масив
    }
}