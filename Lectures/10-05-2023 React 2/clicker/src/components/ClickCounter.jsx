import React from 'react';
import { Button } from "react-bootstrap";

import "./ClickCounter.css";

const ClickCounter = ({ teamName, score, onScoreChange }) => {

    return (
        <div className="clickCounterContainer">
            <div>{teamName}</div>
            <div>
            <Button onClick={() => onScoreChange(teamName, score + 1)}>Increment</Button>
            </div>
            <div onClick={() => onScoreChange(teamName, 0)}>{score}</div>
            <div>
            <Button 
                onClick={() => onScoreChange(teamName, score - 1)}
                disabled={score === 0}
            >
                Decrement
            </Button>
            </div>
        </div>
    )
}

export default ClickCounter;
