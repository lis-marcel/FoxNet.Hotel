import { ref } from "vue";
import Consts from "@/consts"

const URI = Consts.API.concat('rooms');
const headers = {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Methods': 'GET',
    'Access-Control-Allow-Origin': `${URI}`
}

export function useRooms() {
    const Rooms = ref([]);

    async function fetchRooms() {
        fetch(URI, { headers })
        .then(response => response.json())
        .then((data) => (Rooms.value = data))
        .catch(error => console.log(error));
    }

    return {
        Rooms,
        fetchRooms
    };
}