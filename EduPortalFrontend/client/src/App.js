import React from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        {/* <img src={logo} className="App-logo" alt="logo" /> */}
        <h1>
          Welcome to Education Portal!
        </h1>
        <div>
          Download, share and estimate educational materials fast and efficiently!
        </div>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Click here to Log In
        </a>
      </header>
    </div>
  );
}

export default App;
