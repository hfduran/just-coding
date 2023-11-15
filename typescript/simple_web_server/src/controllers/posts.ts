import {Request, Response, NextFunction} from 'express';
import {PostsServices} from '../services/posts';

export default class PostsController {
  postsServices: PostsServices;
  constructor(postsServices: PostsServices) {
    this.postsServices = postsServices;
  }
  async getPosts(req: Request, res: Response, next: NextFunction) {
    const {code, data} = this.postsServices.get();
    return res.status(code).json(data);
  }
}
