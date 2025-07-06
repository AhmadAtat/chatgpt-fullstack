<template>
    <div class="chat">
        <h2>AI Chat (GPT-3.5)</h2>
        <div v-for="(msg, index) in messages" :key="index">
            <strong>{{ msg.role }}:</strong> {{ msg.content }}
        </div>
        <input v-model="userMessage" @keyup.enter="sendMessage" placeholder="Type your message..." />
    </div>
</template>

<script setup>
    import { ref } from 'vue'

    const userMessage = ref('')
    const messages = ref([])

    const sendMessage = async () => {
        if (!userMessage.value) return
        const userMsg = { role: 'user', content: userMessage.value }
        messages.value.push(userMsg)

        const res = await fetch(`${import.meta.env.VITE_API_BASE_URL}/chat`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ message: userMessage.value })
        });
        const data = await res.json()
        const reply = data.choices[0].message
        messages.value.push(reply)

        userMessage.value = ''
    }
</script>

<style>
    .chat {
        max-width: 600px;
        margin: 50px auto;
        font-family: Arial;
    }

    input {
        width: 100%;
        padding: 10px;
        margin-top: 20px;
    }
</style>
