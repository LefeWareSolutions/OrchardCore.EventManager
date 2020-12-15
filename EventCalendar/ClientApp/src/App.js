import { hot } from 'react-hot-loader';
import React, { Component } from "react";
import { ApolloProvider, ApolloClient, InMemoryCache  } from '@apollo/client';
import CalendarContainer from './components/calendar/CalendarContainer';

const host = window.location.hostname;
let baseUrl = `https://${host}`
if(window.location.port){
  baseUrl = `${baseUrl}:${window.location.port}`
}
const tenantName = (window.location.pathname.split("/"))[1];
const client = new ApolloClient({
  uri:  `${baseUrl}/${tenantName}/api/graphql`,
  cache: new InMemoryCache()
});

class App extends Component {

  render() {
    return (
      <div className="App">
        <ApolloProvider client={client}>
            <CalendarContainer/>
          </ApolloProvider>
      </div>
    );
  }
}
export default hot(module)(App);
