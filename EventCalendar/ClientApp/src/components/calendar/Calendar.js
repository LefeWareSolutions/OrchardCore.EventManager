import React, { useState } from 'react'
import { Calendar as BigCalendar, momentLocalizer } from 'react-big-calendar'
import moment from 'moment'
import "react-big-calendar/lib/css/react-big-calendar.css";
import EventModal from './EventModal';

const localizer = momentLocalizer(moment)



export default function Calendar({events}) {
  const [show, setShow] = useState(false);
  const [selectedEvent, setEvent] = useState({})

  const handleClose = () => setShow(false);
  
  const handleShow = (event) =>{
    const selectedEvent = events.find(x=>x.contentItemId === event.resource)
    const {description, thumbnail } = selectedEvent.event;
    const imageUrl = thumbnail.urls[0];
    setEvent({...event, description, imageUrl});
    setShow(true);
  }
    

  const calendarEvents = events.map(x=>{
    return {
      start: moment(x.event.startDate).toDate(),
      end: moment(x.event.endDate).toDate(),
      title: x.displayText,
      resource: x.contentItemId
    }
  });
  return (
    <div>
      <BigCalendar
        selectable={true}
        localizer={localizer}
        defaultDate={new Date()}
        defaultView="month"
        events={calendarEvents}
        style={{ height: "100vh" }}
        onSelectEvent={(slot) => handleShow(slot)}
      />
      <EventModal 
        show={show} 
        handleClose={handleClose} 
        event={selectedEvent}
      />
    </div>
  )
}
