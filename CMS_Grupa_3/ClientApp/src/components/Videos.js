import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { Player, ControlBar } from 'video-react';
import "video-react/dist/video-react.css";
import Show_Video from './Show_Video';

class Videos extends Component {


    constructor(props) {
        super(props);
        this.state = { videos: []}
        fetch('api/MediaFiles')
            .then(response => response.json())
            .then(data => {
                this.setState({
                   videos: data
                });
            });
    }


    render() {
        return (
            <div>
                {this.state.videos.map(video =>
                    <div>
                    <h2>-----------------</h2>
                    <Show_Video video={video} />
                    </div>
                )}
            </div>
        );
    }
}



export default connect()(Videos);
