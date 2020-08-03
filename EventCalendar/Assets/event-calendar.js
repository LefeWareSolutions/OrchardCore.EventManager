import moment from 'moment';
import { Calendar } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';

document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new Calendar(calendarEl, {
        plugins: [dayGridPlugin, interactionPlugin],
        themeSystem: 'bootstrap',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
        },
        dayMaxEvents: true, // allow "more" link when too many events
        selectable: true,

        events: [
            {
                title: 'The Title', 
                start: '2020-08-02', 
                end: '2020-08-02' 
            }
        ],

        select: function ({ start, end, jsEvent, view }) {
            // set values in inputs
            $('#event-modal').find('input[name=startDate]').val(
                moment(start, 'YYYY-MM-DD HH:mm:ss')
            );

            $('#event-modal').find('input[name=endDate]').val(
               moment(end, 'YYYY-MM-DD HH:mm:ss')
            );

            // show modal dialog
            $('#event-modal').modal('show');

            $("#event-modal").find('form').on('submit', function () {
                let data = $("#event-modal").serialize();
                $.ajax({
                    url: '~/api/events',
                    data: data,
                    type: 'post',
                    dataType: 'json',
                    success: function(response) {
                        // if saved, close modal
                        $("#event-modal").modal('hide');
                    
                        // refetch event source, so event will be showen in calendar
                        $("#calendar").fullCalendar( 'refetchEvents' );
                    }
                });
            });
        },

        eventClick: function (info) {
            alert('Event: ' + info.event.title);
            alert('Coordinates: ' + info.jsEvent.pageX + ',' + info.jsEvent.pageY);
            alert('View: ' + info.view.type);

            // change the border color just for fun
            info.el.style.borderColor = 'red';
        }
    });

    calendar.render();
});