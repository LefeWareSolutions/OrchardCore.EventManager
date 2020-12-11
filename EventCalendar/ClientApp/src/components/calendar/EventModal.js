import React from 'react'
import Modal from 'react-bootstrap/Modal'
import Button from 'react-bootstrap/Button'

export default function EventModal({show, handleClose, event}) {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{event.title}</Modal.Title>
      </Modal.Header>

      <Modal.Body>
        <p>Start Date:{event.start?.toString()}</p>
        <p>End Date:{event.end?.toString()}</p>
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
