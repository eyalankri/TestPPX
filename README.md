# PPX Interview Tasks

## Task 1: CustomerPOS
Extended POS welcome message with country-specific greetings.
- **Input**: Country and optional greeting
- **Output**: "Hello Passport-X Italy customer" or "Hola Passport-X Spain customer"

## Task 2: PromotionEngine
Fixed bugs and performance issues in discount calculation system.

### Issues Fixed
- **Logic Bug**: Now applies discounts from any available provider (not just both)
- **Calculation Bug**: Discounts calculated from original price and summed
- **Performance**: Providers created once, item IDs loaded at startup
- **Error Handling**: Provider failures don't crash system

### Architecture
- Supports Visa and Loyalty providers
- Easily extensible for new providers
- Production-ready with logging and error handling

### Limitations
- Provider APIs only support single-item requests (no batch processing)
- Performance constrained by external API design (100-300ms delays per call)