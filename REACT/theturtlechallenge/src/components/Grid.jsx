import React from "react";
import { connect } from "react-redux";
import { Direction } from "../constants";

class Tile extends React.Component{    
    render(){
        let posStyle = {
            top: 20 * (this.props.Y - 1),
            left: 20 * (this.props.X - 1)
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
        direction: state.direction
    };
}

class ConnectedGrid extends React.Component{
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

                tiles.push(<Tile X={i+1} Y={k+1} isMine={(isMine != undefined)} isCurrentPosition={isCurrentPosition} />);
            }
        }
        
        let tilesSizeStyle = {
            width: 20 * (size.X + 1),
            height: 20 * (size.Y + 1)
        };

        return(
            <div className="grid">                
                <div className="position-info">
                    <div>{this.props.currentPosition.X} - {this.props.currentPosition.Y}</div>
                    <div>{Object.keys(Direction).find(k => Direction[k] === this.props.direction)}</div>
                </div>
                <div className="tiles" style={tilesSizeStyle}>
                    {tiles}
                </div>
            </div>            
        );
    }
}

export const Grid = connect(mapStateToProps)(ConnectedGrid);