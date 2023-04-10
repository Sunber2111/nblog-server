export const getSmallText = (text: string, size: number, endWords = '...') => {
  let output = '';
  const arr = text.split(' ');
  for (let index = 0; index < arr.length; index++) {
    if ((output + arr[index]).length > size) {
      break;
    } else {
      output = `${output} ${arr[index]}`;
    }
  }
  return `${output} ${endWords}`;
};
