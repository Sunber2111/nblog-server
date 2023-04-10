'use client';
import { LoadingProfilerStyled } from './styled';

const LoadingProfiler = () => {
  return (
    <LoadingProfilerStyled>
      <div className="clearfix header">
        <div className="loading loading_image"></div>
        <div className="loading loading_header"></div>
        <div className="loading loading_header"></div>
      </div>
      <div>
        <div className="loading loading_text"></div>
        <div className="loading loading_text"></div>
      </div>
    </LoadingProfilerStyled>
  );
};

export default LoadingProfiler;
