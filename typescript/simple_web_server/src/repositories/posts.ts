import {Post} from '../interfaces/posts';

export default class PostsRepository {
  private static instance: PostsRepository;

  /**
   * The Singleton's constructor should always be private to prevent direct
   * construction calls with the `new` operator.
   */
  private constructor() {}

  /**
   * The static method that controls the access to the singleton instance.
   *
   * This implementation let you subclass the Singleton class while keeping
   * just one instance of each subclass around.
   */
  public static getInstance(): PostsRepository {
    if (!PostsRepository.instance) {
      PostsRepository.instance = new PostsRepository();
    }

    return PostsRepository.instance;
  }

  private posts: Post[] = [
    {
      title: 'Lorem ipsum dolor sit amet',
      body: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ut aliquet diam.',
      id: '1',
      userId: '1',
    },
    {
      title: 'Gatos são legais',
      body: 'Gatos são legais, mas cachorros são melhores.',
      id: '2',
      userId: '2',
    },
  ];

  public getPosts(): Post[] {
    return this.posts;
  }
}
