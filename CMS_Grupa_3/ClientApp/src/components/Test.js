import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import axios from 'axios';
import ThemeSwitcher from './ThemeSwitcher';

class Test extends Component {


    constructor(props) {
        super(props);
        this.state = { number: 0, text: 'x' }
    }
    testHandler = () => {
      this.setState({number: this.state.number + 1})
      this.setState({ text: this.state.number})
  }

    render() {
        return (
            <div>

              <h2>Text: {this.state.text} , number: {this.state.number}</h2>
              <button onClick={this.testHandler}>Upload</button>
              <p><ThemeSwitcher/></p>
            </div>
        );
    }
}



export default Test;
