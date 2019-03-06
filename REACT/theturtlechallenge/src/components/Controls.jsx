import React from "react";
import { connect } from "react-redux";
import {moveTurtle, rotateTurtle} from "../actions/index";

function mapDispatchToProps(dispatch){
    return{
        moveTurtle: () => dispatch(moveTurtle()),
        rotateTurtle: () => dispatch(rotateTurtle())
    }
}

class ConnectedControls extends React.Component{

    constructor(){
        super();
        this.handleMove = this.handleMove.bind(this);
        this.handleRotation = this.handleRotation.bind(this);
    }

    handleMove(event){
        event.preventDefault();
        this.props.moveTurtle();
    }

    handleRotation(event){
        event.preventDefault();
        this.props.rotateTurtle();
    }

    render(){
        return(
            <div className="controls">
                <button onClick={this.handleMove} value="M">M</button>
                <button onClick={this.handleRotation} value="R">R</button>
            </div>
        );
    }
}

export const Controls = connect(null, mapDispatchToProps)(ConnectedControls);