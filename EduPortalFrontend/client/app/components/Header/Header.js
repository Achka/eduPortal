import React from 'react';
import { Link } from 'react-router-dom';
import Banner from './images/banner.jpg';
import './style.scss';

class Header extends React.Component { // eslint-disable-line react/prefer-stateless-function
  render() {
    return (
      <div className="header">
        <div className="main-page">

        <i className="fa fa-fw fa-home"></i>
        <Link className="router-link" to="/home">EduPortal
        </Link>
        </div>
        <div className="account-info">
        <i class="fa fa-user" aria-hidden="true"></i>
        <Link className="router-link" to="/profile">Anna
        </Link>
        </div>
        {/* <a href="https://twitter.com/flexdinesh">
          <img src={Banner} alt="react-redux-boilerplate - Logo" />
        </a>
        <div className="nav-bar">
          <Link className="router-link" to="/">
            Home
          </Link>
          <Link className="router-link" to="/features">
            Features
          </Link>
        </div> */}

      </div>
    );
  }
}

export default Header;
