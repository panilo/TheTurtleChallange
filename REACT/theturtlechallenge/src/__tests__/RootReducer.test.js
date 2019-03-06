import rootReducer from '../reducers/index';
import {rotateTurtle} from '../actions/index';
import {Direction, TurtleStatus} from '../constants/index';

test('no state passed', () =>{    
  expect(rootReducer(undefined, {})).toEqual({
    currentPosition: {X:0,Y:0},
    direction:Direction.North,
    turtleStatus:TurtleStatus.StillInDanger,
    mines:[{X:3,Y:2},{X:1,Y:4},{X:5,Y:2}],
    gridSize:{X:5,Y:4}
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