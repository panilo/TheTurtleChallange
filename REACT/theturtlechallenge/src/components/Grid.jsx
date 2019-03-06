import React from "react";
import uuidv1 from "uuid";
import { connect } from "react-redux";
import { Direction, TurtleStatus } from "../constants";

class Tile extends React.Component{    
    render(){
        let posStyle = {
            top: 20 * this.props.Y,
            left: 20 * this.props.X
        }

        let isMine = this.props.isMine;
        let currentPosition = this.props.isCurrentPosition;
        let tileClassName = "tile" + ((isMine) ? " isMine" : "") + ((currentPosition) ? " currentPosition" : ""); 

        return(
            <div style={posStyle} className={tileClassName}></div>
        );
    }
}

const mapStateToProps = state => {
    return{
        currentPosition: state.currentPosition,
        direction: state.direction,
        turtleStatus: state.turtleStatus,
        gridSize: state.gridSize,
        mines: state.mines
    };
}

class ConnectedGrid extends React.Component{
    constructor(){
        super();
    }

    render(){   
        
        let size = this.props.gridSize;            
        let currentPosition = this.props.currentPosition;    
        let mines = this.props.mines;

        var tiles = Array(size.X * size.Y);        
        for(var i=0; i<size.X; i++){
            for(var k=0; k<size.Y; k++){            
                let isCurrentPosition = (i === currentPosition.X && k === currentPosition.Y);
                let isMine = mines.find(function(m){ return (i === m.X && k === m.Y); } );

                tiles.push(<Tile key={uuidv1()} X={i} Y={k} isMine={(isMine !== undefined)} isCurrentPosition={isCurrentPosition} />);
            }
        }
        
        let tilesSizeStyle = {
            width: 20 * (size.X + 1),
            height: 20 * (size.Y + 1)
        };

        return(
            <div className="grid">                
                <div className="position-info">                    
                    <div>{this.props.currentPosition.X + 1} - {this.props.currentPosition.Y + 1}</div>
                    <div>{Object.keys(Direction).find(k => Direction[k] === this.props.direction)}</div>
                    <div className="turtleStatus">{Object.keys(TurtleStatus).find(k => TurtleStatus[k] === this.props.turtleStatus)}</div>
                </div>
                <div className="tiles" style={tilesSizeStyle}>
                    {tiles}
                </div>
            </div>            
        );
    }
}

export const Grid = connect(mapStateToProps)(ConnectedGrid);