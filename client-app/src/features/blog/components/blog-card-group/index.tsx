'use client';

import { getSmallText } from '@/common/utils';
import Image from 'next/image';
import React from 'react';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { useRouter } from 'next/navigation';

const BlogCardGroup = () => {
  const router = useRouter();

  return (
    <Row xs={1} md={4} className="g-4">
      {Array.from({ length: 10 }).map((_, idx) => (
        <Col onClick={() => router.push('/blog/343/34534')}>
          <Card>
            <Image
              height={200}
              width={200}
              alt="img-blog-post"
              className="card-img-top"
              src={`https://picsum.photos/seed/${idx + 1}/800/600`}
            />
            <Card.Body>
              <Card.Title>Card title</Card.Title>
              <Card.Text>
                {getSmallText(
                  'This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.',
                  43
                )}
              </Card.Text>
            </Card.Body>
          </Card>
        </Col>
      ))}
    </Row>
  );
};

export default BlogCardGroup;
