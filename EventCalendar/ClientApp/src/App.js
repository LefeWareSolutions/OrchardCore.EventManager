import { hot } from 'react-hot-loader';
import React, { Component } from "react";
import { ApolloProvider, ApolloClient, InMemoryCache  } from '@apollo/client';
import CalendarContainer from './components/calendar/CalendarContainer';

const tenantName = "";
const client = new ApolloClient({
  uri:  `https://localhost:44300/${tenantName}/api/graphql`,
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
