/*
 * CoursesPage
 *
 * This is the first thing users see of our App, at the '/' route
 */

import React from 'react';
import './style.scss';

export default class ProfilePage extends React.PureComponent { // eslint-disable-line react/prefer-stateless-function
  /**
   * when initial state username is not null, submit the form to load repos
   */
  componentDidMount() {
    const { username, onSubmitForm } = this.props;
    if (username && username.trim().length > 0) {
      onSubmitForm();
    }
  }

  render() {
    const {
      loading, error, repos, username, onChangeUsername, onSubmitForm
    } = this.props;
    const reposListProps = {
      loading,
      error,
      repos
    };

    return (
      <article>
     
        <div className="profile-page">
        Profile Page
        </div>
      </article>
    );
  }
}

