import ClickCounter from './components/ClickCounter';

import './App.css';

const App = () => {
  return (
    <div className="App">
      <ClickCounter title="Team One" startingValue={5}></ClickCounter>
      <ClickCounter title="Team Two" startingValue={15}></ClickCounter>
      <ClickCounter title="Team Three" startingValue={0}></ClickCounter>
    </div>
  );
}

export default App;
