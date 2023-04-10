'use client';
import { MarkDownPreview } from '@/common/components';
import React from 'react';
import { Container } from 'react-bootstrap';

interface IProps {
  content: string;
}

const BlogDetailContainer = (props: IProps) => {
  return (
    <Container>
      <MarkDownPreview text={props.content} />
    </Container>
  );
};

export default BlogDetailContainer;
