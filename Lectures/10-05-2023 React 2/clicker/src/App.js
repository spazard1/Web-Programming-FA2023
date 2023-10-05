import { useCallback, useEffect, useState } from 'react';
import ClickCounter from './components/ClickCounter';

import './App.css';

const App = () => {
  const [teamScores, setTeamScores] = useState({});

  const onScoreChange = useCallback((teamName, score) => {
    setTeamScores({...teamScores, [teamName]: score});
  }, [teamScores]);

  const updateDocumentTitle = useCallback((ts) => {
    document.title = `Team One: ${ts["Team One"] ?? 0} | Team Two: ${ts["Team Two"] ?? 0}`;
  }, []);

  useEffect(() => {
    updateDocumentTitle(teamScores);
  }, [teamScores, updateDocumentTitle]);

  return (
    <div className="App">
      {["Team One", "Team Two"].map((teamName) => (
        <ClickCounter
          key={teamName}
          teamName={teamName}
          score={teamScores[teamName] ?? 0}
          onScoreChange={onScoreChange}
        />
      ))}
    </div>
  );
}

export default App;
