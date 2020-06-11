/*
 * FeaturePage
 *
 * List all the features
 */
import React from 'react';
import { Helmet } from 'react-helmet';
import './style.scss';
import { withRouter } from 'react-router-dom';

export class FeaturePage extends React.Component {

  constructor(props) {
    super(props);

    this.goToPage = this.goToPage.bind(this);
  }

  // eslint-disable-line react/prefer-stateless-function

  // Since state and props are static,
  // there's no need to re-render this component
  shouldComponentUpdate() {
    return false;
  }

  render() {
    return (
      <div className="feature-page">
        <div className="card" data-type="courses" onClick={this.goToPage}>

          <h2 className="card-title"><i className="fa fa-list-alt" aria-hidden="true"></i>Courses</h2>
          <p className="card-desc">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
          </p>
        </div>
        <div className="card" data-type="lecturers" onClick={this.goToPage}>
          <h2 className="card-title"> <i className="fa fa-address-book" aria-hidden="true"></i>Lecturers</h2>
          <p className="card-desc">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
          </p>
        </div>
        <div className="card" data-type="students" onClick={this.goToPage}>
          <h2 className="card-title"> <i className="fa fa-graduation-cap" aria-hidden="true"></i>Students</h2>
          <p className="card-desc">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
          </p>
        </div>
      </div>
    );
  }

  goToPage(e) {
    if (!e || !e.target || !e.target.getAttribute('data-type')) return;
    
    const {history} = this.props;

    history.push(`/${e.target.getAttribute('data-type')}`);
  }
}


export default withRouter(FeaturePage);