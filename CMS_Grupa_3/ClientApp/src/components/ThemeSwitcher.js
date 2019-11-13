import React, { Component } from 'react';
import { Button, ButtonDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

class ThemeSwitcher extends Component {

  state = { theme: null, dropdownOpen: false }
  
  toggleDropdown = () => {
    this.setState({ dropdownOpen: !this.state.dropdownOpen });
  }
  
  resetTheme = evt => {
    evt.preventDefault();
    this.setState({ theme: null });
  }
  
  chooseTheme = (theme, evt) => {
    evt.preventDefault();
    this.setState({ theme });
  }
  
  render() {
  
    const { theme, dropdownOpen } = this.state;
    const themeClass = theme ? theme.toLowerCase() : 'secondary';
    
    return (
      <div className="d-flex flex-wrap justify-content-center align-items-center align-content-center">
      
        <span className={`h1 mb-4 w-100 text-center text-${themeClass}`}>{theme || 'Default'}</span>
        <Button id="test" color={themeClass}>Test</Button>
        <div>___</div>
        <ButtonDropdown isOpen={dropdownOpen} toggle={this.toggleDropdown}>
          <Button id="caret" color={themeClass}>{theme || 'Custom'} Theme</Button>
          <DropdownToggle caret size="lg" color={themeClass} />
          <DropdownMenu>
            <DropdownItem onClick={e => this.chooseTheme('Primary', e)}>Primary Theme</DropdownItem>
            <DropdownItem onClick={e => this.chooseTheme('Dark', e)}>Dark Theme</DropdownItem>
            <DropdownItem onClick={e => this.chooseTheme('Light', e)}>Light Theme</DropdownItem>
            <DropdownItem divider />
            <DropdownItem onClick={this.resetTheme}>Default Theme</DropdownItem>
          </DropdownMenu>
        </ButtonDropdown>
        
      </div>
    );
    
  }
  
}

export default ThemeSwitcher;