import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Jumbotron} from 'reactstrap';

class Show_Post extends Component {


    constructor(props) {
        super(props);
        this.state = { id: '' }
    }


    render() {
        return (
            <div>
                <Jumbotron className='jumbotron bg-light'>
                    <h1>Post_Id: {this.props.post.postId}</h1> 
                    <div dangerouslySetInnerHTML={{ __html: this.props.post.postHtml }}></div>
                </Jumbotron>
            </div>
        );
    }
}



export default connect()(Show_Post);