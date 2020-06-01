import styled from 'styled-components';

export const Page = styled.div`
    height: calc(100% - 40px);
    margin: 0 10% 0 10%; 
    width: 80%;
    padding: 20px 0 0 0;
`;

export const TextAreaContainer = styled.div`
    height: calc(100% - 70px);
    width: 100%;
`

export const TextArea = styled.textarea`
    height: 100%;
    width: 100%;
    overflow: auto;
`;

export const ButtonsContainer = styled.div`
    height: 70px;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;

    button:not(:last-child){
        margin-right: 20px;
    }
`