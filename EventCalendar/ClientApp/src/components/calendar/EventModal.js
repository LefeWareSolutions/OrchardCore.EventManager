import React from 'react'
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'

export default function EventModal({show, handleClose, event}) {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{event.title}</Modal.Title>
      </Modal.Header>

      <Modal.Body style={{display: 'flex', flexDirection: 'column'}}>
        <img src={event.imageUrl} style={{maxHeight:300}}/><br/>
        <div>
          <b>Start Time: </b>{event.start?.toLocaleString()}<br/>
        </div>
        <div>
          <b>End Time: </b>{event.end?.toLocaleString()}
        </div>
        <b>Description: </b>{event.description}<br/>
      </Modal.Body>

      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={handleClose}>
          Ok
        </Button>
      </Modal.Footer>
    </Modal>
  )
}
