import { BaseServices } from '@/services';

class BlogServices extends BaseServices {
  constructor() {
    super(process.env.REACT_APP_BLOG_SERVICE_URL);
  }
}

export default new BlogServices();
