import { http, HttpResponse } from "msw";

const response = [
    { id: "1", title: "Destiny 2"},
    { id: "2", title: "Jetbrains Rider"},
    { id: "3", title: "Notepad"}
]
const handlers = [
    http.get("http://localhost:1337/api/software", () => {
        return HttpResponse.json(response)
    })
]

export default handlers;