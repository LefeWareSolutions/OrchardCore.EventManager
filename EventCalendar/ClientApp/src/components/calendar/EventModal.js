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
        <img src={event.imageUrl}/><br/>
        <b>Description: </b>{event.description}<br/>
        <b>Start Date: </b>{event.start?.toString()}<br/>
        <b>End Date: </b>{event.end?.toString()}
      </Modal.Body>

      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={handleClose}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  )
}
