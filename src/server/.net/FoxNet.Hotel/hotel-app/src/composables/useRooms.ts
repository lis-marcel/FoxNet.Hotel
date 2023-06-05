import { ref, watchEffect } from 'vue';
import Consts from "../consts"

class FiltersOptions {
    FirstDay: any;
    LastDay: any;
};
const filtersOptions = ref<any>(new FiltersOptions());
const Rooms = ref([]);

const filterRoomsAPI = Consts.API.concat(`rooms/search`)
const filtersHeaders = {
    'Content-type': 'application/json; charset=UTF-8',
    'Access-Control-Allow-Methods': 'POST',
    'Access-Control-Allow-Origin': `${filterRoomsAPI}`
}

const roomsAPI = Consts.API.concat(`rooms`)
const roomsHeaders = {
    'Content-type': 'application/json; charset=UTF-8',
    'Access-Control-Allow-Methods': 'GET',
    'Access-Control-Allow-Origin': `${roomsAPI}`
}

export function useRooms() {

    async function fetchFilteredRooms() {
        fetch(filterRoomsAPI, {
            method: 'POST',
            mode: 'cors',
            credentials: 'same-origin',
            body: JSON.stringify(filtersOptions._value), filtersHeaders
        })
        .then(response => response.json())
        .then((data) => (Rooms.value = data))
        .catch(error => console.error(error));
    }

    function fetchRooms() {
        fetch(roomsAPI, {
            method: 'GET',
            mode: 'cors',
            credentials: 'same-origin', roomsHeaders
        })
        .then(response => response.json())
        .then((data) => (Rooms.value = data))
        .catch(error => console.error(error));
    }

    return {
        Rooms,
        fetchRooms,
        filtersOptions,
        fetchFilteredRooms,
    };
}