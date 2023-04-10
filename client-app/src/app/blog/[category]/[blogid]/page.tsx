import { BlogDetailContainer } from '@/features/blog/containers';

const awaitFunc = async () => {
  return new Promise((res, rej) => {
    setTimeout(() => {
      res(234);
    }, 2000);
  });
};

const page = async (param: any) => {
  await awaitFunc();

  return <BlogDetailContainer content="sdfsd" />;
};

export default page;
