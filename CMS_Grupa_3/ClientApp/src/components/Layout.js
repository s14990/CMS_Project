import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import '../Styles.css';

function ModeLayout(props) {
  const [darkMode, setDarkMode] = React.useState(true);

  return(
    <div className = {darkMode? 'dark-mode': 'light-mode'}>
      <h3>{darkMode? 'Dark mode': 'Light mode'}</h3>
      <div className='toggle-container'>
        <button onClick={() => setDarkMode(prevMode => !prevMode)}>Toggle Mode</button>
      </div>
      <NavMenu className = {darkMode? 'dark-mode': 'light-mode'}/>
      <Container>
        {props.children}
      </Container>
    </div>
  );
}

export default props => (

    <ModeLayout props = {props}/>


);
