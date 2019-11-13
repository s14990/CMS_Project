import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink , Nav} from 'reactstrap';
import { Link } from 'react-router-dom';
//import './NavMenu.css';

export default class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false,
      darkMode: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  
  render () {
    const styleMode = {backgroundColor: this.state.darkMode ? '#312441' : '#c1c1f1', color: this.state.darkMode ? '#a1f1a1' : '#012101'};
    return (
      
      <header>
            <Navbar className="navbar navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3 navbar-dark bg-primary"  >
          <Container>
            <NavbarBrand tag={Link} to="/">CMS_Grupa_3</NavbarBrand>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
              <Nav className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                <NavLink tag={Link} className="text-dark" to="/all_posts">Posts</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/test">Test</NavLink>
                </NavItem>
              </Nav>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
