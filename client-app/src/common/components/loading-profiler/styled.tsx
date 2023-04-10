'use client';
import styled from 'styled-components';

export const LoadingProfilerStyled = styled.div`
  height: 500px;
  * {
    height: 100px;
  }
  .header {
    max-width: 150px;
  }
  .loading {
    background: #f6f7f9;
    background-image: linear-gradient(to right, #f6f7f9 0%, #e9ebee 20%, #f6f7f9 40%, #f6f7f9 100%);
    background-repeat: no-repeat;
    background-size: 800px 100px;
    animation: placeHolderShimmer 1s forwards infinite;
    &_image {
      width: 40px;
      height: 40px;
      border-radius: 6px;
      float: left;
      margin: 0 0.5em 0 0;
    }
    &_header {
      width: 100px;
      height: 1em;
      float: left;
      margin: 0.25em 0;
    }
    &_text {
      width: 400px;
      max-width: 100%;
      height: 1em;
      margin: 0.5em 0;
      &:last-child {
        width: 320px;
      }
    }
  }
  @-webkit-keyframes placeHolderShimmer {
    0% {
      background-position: -468px 0;
    }
    100% {
      background-position: 468px 0;
    }
  }
`;
