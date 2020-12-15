import React from 'react'
import gql from 'graphql-tag'
import { useQuery } from '@apollo/client'
import Calendar from './Calendar'


const GET_EVENTS = gql` 
query getEvents {
  event {
    contentItemId
    createdUtc
    displayText
    render
    event {
      startDate
      endDate
      description
      thumbnail {
        urls
      }
    }
  }
}
`

export default function CalendarContainer(){
  const { loading, error, data } = useQuery(GET_EVENTS);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;

  return <Calendar events={data.event}/>
}
