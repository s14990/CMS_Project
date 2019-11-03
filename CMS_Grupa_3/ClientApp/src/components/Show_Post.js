import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { Player, ControlBar } from 'video-react';
import "video-react/dist/video-react.css";
import ReactPlayer from 'react-player'

class Show_Post extends Component {


    constructor(props) {
        super(props);
        this.state = { id: '' }
    }


    render() {
        return (
            <div>
                <h1>Post_Id: {this.props.post.postId}</h1> 
                    <div dangerouslySetInnerHTML={{ __html: this.props.post.postHtml }}></div>
            </div>
        );
    }
}



export default connect()(Show_Post);