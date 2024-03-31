import Swal, { SweetAlertIcon } from "sweetalert2";

export function fireSwal(title: string, text: string, icon: SweetAlertIcon): void {
    Swal.fire({
        title: title,
        text: text,
        icon: icon,
        color: 'white',
        background: '#424242',
        confirmButtonColor: '#ff9800'
    });
}