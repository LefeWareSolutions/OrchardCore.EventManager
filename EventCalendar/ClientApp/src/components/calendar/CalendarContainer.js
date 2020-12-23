import React from 'react'
import {gql, useQuery } from '@apollo/client'
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
    contained {
      listContentItemId
    }
  }
}
`

export default function CalendarContainer(){
  const { loading, error, data } = useQuery(GET_EVENTS);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;
  
  let events = data.event;

  //Filter by contained item stored in local storage
  let containedItemJSON = localStorage.getItem("containedItem")
  if(containedItemJSON){
    let containedItem = JSON.parse(containedItemJSON);
    if(containedItem.id !== "0"){
      events = events.filter(e=>e.contained.listContentItemId === containedItem.id);
    }
  }

  return <Calendar events={events}/>
}
