import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { Player, ControlBar } from 'video-react';
import "video-react/dist/video-react.css";
import ReactPlayer from 'react-player'

class Show_Video extends Component {


    constructor(props) {
        super(props);
        this.state = { id: '',video_name: '', video_link: '', format: ''}
    }


    render() {
        let link = this.props.video.fileLink;
        return (
            <div>
                <h1>{this.props.video.mediaName}</h1>
                <ReactPlayer url={link} controls />
            </div>
        );
    }
}



export default connect()(Show_Video);
