import React from 'react';
import ReactDOM from 'react-dom';
import rootReducer from '../reducers/index';
import {moveTurtle, rotateTurtle} from '../actions/index';
import {ROTATE, Direction} from '../constants/index';

test('no state passed', () =>{    
  expect(rootReducer(undefined, {})).toEqual({
    currentPosition: {X:1,Y:1},
    direction:Direction.North
  });  
});

test('rotate', () =>{    
  expect(rootReducer({direction: Direction.North}, rotateTurtle())).toEqual({
    direction:Direction.East
  });
  expect(rootReducer({direction: Direction.East}, rotateTurtle())).toEqual({
    direction:Direction.South
  });
  expect(rootReducer({direction: Direction.South}, rotateTurtle())).toEqual({
    direction:Direction.West
  });
  expect(rootReducer({direction: Direction.West}, rotateTurtle())).toEqual({
    direction:Direction.North
  });  
});