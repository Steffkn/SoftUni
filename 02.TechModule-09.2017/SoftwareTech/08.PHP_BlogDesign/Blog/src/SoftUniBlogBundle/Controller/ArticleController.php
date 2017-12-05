<?php
/**
 * Created by PhpStorm.
 * User: Steff
 * Date: 29/11/2017
 * Time: 17:08
 */

namespace SoftUniBlogBundle\Controller;

use SoftUniBlogBundle\Form\ArticleType;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use Symfony\Component\HttpFoundation\Request;
use SoftUniBlogBundle\Entity\Article;

class ArticleController extends Controller
{
    /**
     * @param Request $request
     *
     * @Route("/article/create", name="article_create")
     * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
     *
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function createAction(Request $request)
    {
        $article = new Article();
        $form = $this->createForm(ArticleType::class, $article);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()){
            $article-> setAuthor($this->getUser());
            $em = $this->getDoctrine()->getManager();
            $em->persist($article);
            $em->flush();

            return $this->redirectToRoute('blog_index');
        }

        return $this->render('article/create.html.twig',
            ['form' => $form->createView()]
            );
    }

    /**
     * @param $id
     * @return \Symfony\Component\HttpFoundation\Response
     * @Route("article/{id}", name="article_view")
     *
     */
    public function viewArticle ($id){
        $article = $this->getDoctrine()->getRepository(Article::class)->find($id);

        return $this->render('article/view.html.twig', ['article' => $article]);
    }
}