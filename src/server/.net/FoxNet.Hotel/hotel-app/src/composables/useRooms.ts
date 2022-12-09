import { ref, watchEffect } from 'vue';
import Consts from "@/consts"

class FiltersOptions {
    FirstDay: any;
    LastDay: any;
};
const filtersOptions = ref<any>(new FiltersOptions());
const Rooms = ref([]);

export function useRooms() {

    async function fetchFilteredRooms() {
        const filterRoomsAPI = Consts.API.concat(`rooms/search`)
        const headers = {
            'Content-type': 'application/json; charset=UTF-8',
            'Access-Control-Allow-Methods': 'POST',
            'Access-Control-Allow-Origin': `${filterRoomsAPI}`
        }

        fetch(filterRoomsAPI, {
            method: 'POST',
            mode: 'cors',
            credentials: 'same-origin',
            body: JSON.stringify(filtersOptions._value),
            headers
        })
        .then(response => response.json())
        .then((data) => (Rooms.value = data))
        .catch(error => console.error(error));
    }

    return {
        Rooms,
        filtersOptions,
        fetchFilteredRooms,
    };
}