/**
 *
 * App
 *
 * This component is the skeleton around the actual pages, and should only
 * contain code that should be seen on all pages. (e.g. navigation bar)
 */

import React from 'react';
import { Helmet } from 'react-helmet';
import { Switch, Route } from 'react-router-dom';

import HomePage from 'containers/HomePage/Loadable';
import FeaturePage from 'containers/FeaturePage/Loadable';
import NotFoundPage from 'containers/NotFoundPage/Loadable';
import Header from 'components/Header';
import Footer from 'components/Footer';
import './style.scss';
import CoursesPage from 'containers/CoursesPage/Loadable';
import StudentsPage from 'containers/StudentsPage/Loadable';
import LecturersPage from 'containers/LecturersPage/Loadable';
import ProfilePage from 'containers/ProfilePage/Loadable';


const App = () => (
  <div className="app-wrapper">
    <Helmet
      titleTemplate="%s - EduPortal"
      defaultTitle="EduPortal"
    >
      <meta name="description" content="EduPortal application" />
    </Helmet>
    <Header />
    <Switch>
      <Route exact path="/login" component={HomePage} />
      <Route path="/home" component={FeaturePage} />
      <Route path="/courses" component={CoursesPage} />
      <Route path="/students" component={StudentsPage} />
      <Route path="/lecturers" component={LecturersPage} />
      <Route path="/profile" component={ProfilePage} />
      <Route path="" component={NotFoundPage} />
    </Switch>
    {/* <Footer /> */}
  </div>
);

export default App;
