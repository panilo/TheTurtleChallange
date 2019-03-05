import React from "react";
import { connect } from "react-redux";
import { Direction } from "../constants";

class Tile extends React.Component{    
    render(){
        let isMine = this.props.isMine;
        let currentPosition = this.props.isCurrentPosition;
        let tileClassName = "tile" + ((isMine) ? " isMine" : "") + ((currentPosition) ? " currentPosition" : ""); 

        return(
            <div className={tileClassName}></div>
        );
    }
}

const mapStateToProps = state => {
    return{
        currentPosition: state.currentPosition,
        direction: state.direction
    };
}

export class ConnectedGrid extends React.Component{
    constructor(){
        super();
        this.state = {
            size: {X:5,Y:4},                                             
        };
    }

    render(){   
        
        const size = this.state.size;            
        let currentPosition = this.props.currentPosition;    

        var tiles = Array(size.X * size.Y);
        let mines = [{X:3,Y:2},{X:1,Y:4},{X:5,Y:2}];

        for(var i=0; i<size.X; i++){
            for(var k=0; k<size.Y; k++){            
                let isCurrentPosition = ( ((i+1) == currentPosition.X) && ((k+1) == currentPosition.Y) );
                let isMine = mines.find(function(m){ return ( ((i+1) == m.X) && ((k+1) == m.Y) ); } );

                tiles.push(<Tile isMine={(isMine != undefined)} isCurrentPosition={isCurrentPosition} />);
            }
        }
        
        return(
            <div className="grid">
                <div>{this.props.currentPosition.X} - {this.props.currentPosition.Y}</div>
                <div>{Object.keys(Direction).find(k => Direction[k] === this.props.direction)}</div>
                {tiles}
            </div>            
        );
    }
}

export const Grid = connect(mapStateToProps)(ConnectedGrid);