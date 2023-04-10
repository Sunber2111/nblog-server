import styled from "styled-components";

const NavbarStyled = styled.div`
  display: flex;

  width: auto;

  position: absolute;
  top: 1rem;
  left: 1rem;
  right: 1rem;

  .main-nav {
    -webkit-box-shadow: 6px 4px 16px -4px rgba(0, 0, 0, 0.2);
    box-shadow: 6px 4px 16px -4px rgba(0, 0, 0, 0.2);

    width: 100%;

    border-radius: 6px;

    background: hsla(197, 100%, 63%, 1);

    background: linear-gradient(
      0deg,
      hsla(197, 100%, 63%, 1) 0%,
      hsla(294, 100%, 55%, 1) 100%
    );

    background: -moz-linear-gradient(
      0deg,
      hsla(197, 100%, 63%, 1) 0%,
      hsla(294, 100%, 55%, 1) 100%
    );

    background: -webkit-linear-gradient(
      0deg,
      hsla(197, 100%, 63%, 1) 0%,
      hsla(294, 100%, 55%, 1) 100%
    );

    .active.navbar-link{
      background-color: white;
      border-radius: 6px;
      color: black;
    }

    .navbar-link{
        color: white;
        margin-left: 6px;
    }
  }
`;

export default NavbarStyled;
