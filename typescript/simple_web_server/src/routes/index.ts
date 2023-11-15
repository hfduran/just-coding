import {Router} from 'express';
import PostsController from '../controllers/posts';
import {PostsServices} from '../services/posts';
const routes = Router();

const postsServices = new PostsServices();
const postsController = new PostsController(postsServices);

routes.get('/posts', (req, res, next) =>
  postsController.getPosts(req, res, next)
);

export default routes;
