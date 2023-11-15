import {ServiceResponse} from '../interfaces/system';
import PostsRepository from '../repositories/posts';

export class PostsServices {
  private postsRepository: PostsRepository;
  constructor() {
    this.postsRepository = PostsRepository.getInstance();
  }

  get(): ServiceResponse {
    try {
      const posts = this.postsRepository.getPosts();
      return {code: 200, data: posts};
    } catch (err: unknown) {
      console.error(err);
      return {code: 500, data: {error: err}};
    }
  }
}
