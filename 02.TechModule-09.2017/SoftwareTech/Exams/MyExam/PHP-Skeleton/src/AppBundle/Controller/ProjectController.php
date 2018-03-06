<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Project;
use AppBundle\Form\ProjectType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class ProjectController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        //TODO: Implement me ...
        $repo = $this->getDoctrine()->getRepository(Project::class);
        $projects = $repo->findAll();
        return $this->render(
            ":project:index.html.twig",
            ["projects" => projects]
        );
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        //TODO: Implement me ...
        $project = new Project();
        $form = $this->createForm(ProjectType::class, $project);
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->persist($project);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render(
            ":project:create.html.twig",
            ["project" => $project, "form" => $form->createView()]
        );
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
        //TODO: Implement me ...
        $repo = $this->getDoctrine()->getRepository(Project::class);
        $project = $repo->find($id);
        if ($project == null) {
            return $this->redirect("/");
        }
        $form = $this->createForm(ProjectType::class, $project);
        $form->handleRequest($request);
        if ($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->merge($project);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render(
            ":project:edit.html.twig",
            ["project" => $project, "form" => $form->createView()]
        );
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        //TODO: Implement me ...
        $repo = $this->getDoctrine()->getRepository(Project::class);
        $project = $repo->find($id);
        if ($project == null) {
            return $this->redirect("/");
        }
        $form = $this->createForm(ProjectType::class, $project);
        $form->handleRequest($request);
        if ($form->isSubmitted()) {
            $em = $this->getDoctrine()->getManager();
            $em->remove($project);
            $em->flush();
            return $this->redirect("/");
        }
        return $this->render(
            ":project:delete.html.twig",
            ["project" => $project, "form" => $form->createView()]
        );
    }
}
