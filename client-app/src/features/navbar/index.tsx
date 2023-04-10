'use client';

import { useRouter } from 'next/navigation';
import React from 'react';
import { useState, useEffect } from 'react';
import { Navbar as NavB4, Nav, Container } from 'react-bootstrap';
import menu from './configs/router.nav.json';
import NavbarStyled from './styled';
// import './index.scss';

const Navbar = () => {
  const [activeLink, setActiveLink] = useState('home');
  const [scrolled, setScrolled] = useState(false);

  const router = useRouter();

  useEffect(() => {
    const onScroll = () => {
      if (window.scrollY > 50) {
        setScrolled(true);
      } else {
        setScrolled(false);
      }
    };

    window.addEventListener('scroll', onScroll);

    return () => window.removeEventListener('scroll', onScroll);
  }, []);

  const onUpdateActiveLink = (value: string) => {
    setActiveLink(value);
    router.push('/');
  };

  return (
    <NavbarStyled>
      <div className="main-nav">
        <NavB4 expand="md" className={scrolled ? 'scrolled' : ''}>
          <Container>
            <Nav className="ms-auto">
              <Nav.Link
                href="#home"
                className={activeLink === 'home' ? 'active navbar-link' : 'navbar-link'}
                onClick={() => onUpdateActiveLink('home')}
              >
                Design System
              </Nav.Link>
              {menu.map((value) => (
                <Nav.Link
                  href="#skills"
                  className={activeLink === 'skills' ? 'active navbar-link' : 'navbar-link'}
                  onClick={() => onUpdateActiveLink('skills')}
                >
                  {value.name}
                </Nav.Link>
              ))}
            </Nav>
          </Container>
        </NavB4>
      </div>
    </NavbarStyled>
  );
};

export default Navbar;
