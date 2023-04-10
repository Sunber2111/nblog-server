'use client';

import { useState, useEffect } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import headerImg from './assets/header-img.svg';
import 'animate.css';
import BannerStyled from './styled';
import Image from 'next/image';

interface IProps {
  className?: string;
}

export const Banner = ({ className = '' }: IProps) => {
  const [isVisible] = useState(true);
  const [loopNum, setLoopNum] = useState(0);
  const [isDeleting, setIsDeleting] = useState(false);
  const [text, setText] = useState('');
  const [delta, setDelta] = useState(300 - Math.random() * 100);
  const [index, setIndex] = useState(1);
  const toRotate = ['Web Developer', 'Web Designer', 'UI/UX Designer'];
  const period = 2000;

  useEffect(() => {
    let ticker = setInterval(() => {
      tick();
    }, delta);

    return () => {
      clearInterval(ticker);
    };
  }, [text]);

  const tick = () => {
    let i = loopNum % toRotate.length;
    let fullText = toRotate[i];
    let updatedText = isDeleting
      ? fullText.substring(0, text.length - 1)
      : fullText.substring(0, text.length + 1);

    setText(updatedText);

    if (isDeleting) {
      setDelta((prevDelta) => prevDelta / 2);
    }

    if (!isDeleting && updatedText === fullText) {
      setIsDeleting(true);
      setIndex((prevIndex) => prevIndex - 1);
      setDelta(period);
    } else if (isDeleting && updatedText === '') {
      setIsDeleting(false);
      setLoopNum(loopNum + 1);
      setIndex(1);
      setDelta(500);
    } else {
      setIndex((prevIndex) => prevIndex + 1);
    }
  };

  return (
    <BannerStyled className={`banner ${className}`} id="home">
      <Container>
        <Row className="aligh-items-center">
          <Col xs={12} md={6} xl={7}>
            <div className={isVisible ? 'animate__animated animate__fadeIn' : ''}>
              <span className="tagline">Welcome to my Portfolio</span>
              <h1>
                {`Hi! I'm Nam Dang`}{' '}
                <span
                  className="txt-rotate"
                  data-rotate='[ "Web Developer", "Web Designer", "UI/UX Designer" ]'
                >
                  <span className="wrap">{text}</span>
                </span>
              </h1>
              <p>
                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                Ipsum has been the industry's standard dummy text ever since the 1500s, when an
                unknown printer took a galley of type and scrambled it to make a type specimen book.
              </p>
              <button className="custom-btn btn-15">Read More</button>
            </div>
          </Col>
          <Col xs={12} md={6} xl={5}>
            <div className={isVisible ? 'animate__animated animate__zoomIn' : ''}>
              <Image src={headerImg} alt="Picture of the author" width={500} height={500} />
            </div>
          </Col>
        </Row>
      </Container>
    </BannerStyled>
  );
};
