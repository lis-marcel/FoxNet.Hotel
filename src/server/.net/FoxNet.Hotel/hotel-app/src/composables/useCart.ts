import { computed, ref } from "vue"

const CartItems = ref([]);

export const useCart = () => {

    const cartItemsCounter = computed(() => CartItems.value.length);
    const addToCart = (product: any) => {
        CartItems.value.push(product);
    };

    return {
        addToCart,
        cartItemsCounter,
        CartItems,
    }
}