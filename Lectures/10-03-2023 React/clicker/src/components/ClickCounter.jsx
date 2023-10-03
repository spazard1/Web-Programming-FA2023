import React, { useState } from 'react';
import { Button } from "react-bootstrap";

import "./ClickCounter.css";

const ClickCounter = ({ title, startingValue }) => {
    const [counterValue, setCounterValue] = useState(startingValue ?? 0);

    return (
        <div className="clickCounterContainer">
            <div>{title}</div>
            <div>
            <Button onClick={() => setCounterValue(counterValue + 1)}>Increment</Button>
            </div>
            <div onClick={() => setCounterValue(0)}>{counterValue}</div>
            <div>
            <Button 
                onClick={() => setCounterValue(counterValue - 1)}
                disabled={counterValue === 0}
            >
                Decrement
            </Button>
            </div>
        </div>
    )
}

export default ClickCounter;
